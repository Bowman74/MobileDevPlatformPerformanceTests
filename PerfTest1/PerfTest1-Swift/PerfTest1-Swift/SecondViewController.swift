//
//  SecondViewController.swift
//  PerfTest1-Swift
//
//  Created by kevin Ford on 10/3/15.
//  Copyright © 2015 kevin Ford. All rights reserved.
//

import Foundation

class SecondViewController : UIViewController, UITextFieldDelegate {
    
    @IBOutlet var txtMaxPrime: UITextField!
    
    
    func textFieldShouldReturn(textField: UITextField) -> Bool {
        textField.resignFirstResponder()
        return true;
    }
    
    @IBAction func btnCalcPrimesTouched(sender: UIButton) {
        let val = Int32(txtMaxPrime.text!)
        
        if (val != nil) {
            let returnValue = PrimeCalculator.getPrimesFromSieve(val!)
            let returnString = String(format: "%d", returnValue)

            let alert = UIAlertController(title: "Prime Calculation Complete", message: String(format: "Largest prime found: %@", returnString), preferredStyle: UIAlertControllerStyle.Alert)
            alert.addAction(UIAlertAction(title: "Ok", style: UIAlertActionStyle.Destructive, handler: nil))
            self.presentViewController(alert, animated: true, completion: nil)
        } else {
            
            let alert = UIAlertController(title: "Prime Calculation Error", message: String(format: "Must enter a numeric max value: %@", txtMaxPrime.text!), preferredStyle: UIAlertControllerStyle.Alert)
            alert.addAction(UIAlertAction(title: "Ok", style: UIAlertActionStyle.Destructive, handler: nil))
            self.presentViewController(alert, animated: true, completion: nil)
        }
    }
 }