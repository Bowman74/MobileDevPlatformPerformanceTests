//
//  ViewController.swift
//  PerfTest1-Swift
//
//  Created by kevin Ford on 10/3/15.
//  Copyright © 2015 kevin Ford. All rights reserved.
//

import UIKit

class FirstViewController: UIViewController, UITableViewDelegate, UITableViewDataSource {
    
    @IBOutlet var grdRegistrations: UITableView!
    
    var tableData: NSArray
    var client: MSClient?

    required init?(coder aDecoder: NSCoder) {
        tableData = NSArray()
        super.init(coder: aDecoder)
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.
        client  = MSClient(applicationURLString:"https://malor2014jsmobileservice.azure-mobile.net/",
            applicationKey:"pdFskoBXcwzaDNTpuRWdVRhUIRYcFF14")
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    
    @IBAction func btnClearTouched(sender: UIButton) {
        tableData = NSArray()
        self.grdRegistrations.reloadData()
    }
    
    @IBAction func btnFetchResultsTouched(sender: UIButton) {
        var table : MSTable = (client?.tableWithName("Registration"))!
        
        var query: MSQuery = table.query()
        
        query.fetchLimit = 1000;
        
        query.readWithCompletion({
            (items: MSQueryResult!, error: NSError!) -> Void in
            if (error != nil) {
                NSLog(String(format: "ERROR %@", error.debugDescription))
            } else {
                self.tableData = items.items
                self.grdRegistrations.reloadData();
            }
        })
    }
    
    func tableView(tableView: UITableView, numberOfRowsInSection section: Int) -> Int {
        return tableData.count
        //return 0
    }
    
    func tableView(tableView: UITableView, cellForRowAtIndexPath indexPath: NSIndexPath) -> UITableViewCell {
        let simpleTableIdentifier: String = "SimpleTableItem";
        
        var cell:UITableViewCell? = tableView.dequeueReusableCellWithIdentifier(simpleTableIdentifier)
        if (cell == nil) {
            cell = UITableViewCell(style:UITableViewCellStyle.Default, reuseIdentifier:simpleTableIdentifier)
        }
        
        // Configure the cell...
        let item : NSMutableDictionary  = tableData.objectAtIndex(indexPath.row) as! NSMutableDictionary
        cell!.textLabel?.text = item.objectForKey("screenname") as! String?
        
        return cell!
    }
}

