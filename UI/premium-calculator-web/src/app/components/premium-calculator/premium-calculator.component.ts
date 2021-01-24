import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { CalculatorService } from 'src/app/services/calculator.service';
import { CustomerModel } from 'src/app/common/models/calculator-model';

@Component({
  selector: 'app-premium-calculator',
  templateUrl: './premium-calculator.component.html',
  styleUrls: ['./premium-calculator.component.css']
})

export class PremiumCalculatorComponent {
  occupationList = [];
  calculatedPremium: string;

  profileForm = this.fb.group({
    name: ['', Validators.required],
    age: ['', Validators.required],
    dob: [null, Validators.required],
    sumInsured: ['', [Validators.required]],
    occupationOptions: []
  });


  constructor(private fb: FormBuilder, private calculatorService: CalculatorService) {
    this.getOccupationList();
  }

  get profileFormControl() {
    return this.profileForm.controls;
  }

  getOccupationList() {
    this.calculatorService.getAllOccupation()
      .subscribe(
        (result) => {
          this.occupationList = result;
        },
        (error) => {
          console.log('There was an error loading OccupationList', error);
        }
      );

  }

  public calculatePremiumByOccupation(formData: any): void {

    var customerData = new CustomerModel();

    customerData.age = formData.age;
    customerData.dob = formData.dob;
    customerData.name = formData.name;
    customerData.occupationId = Number(formData.occupationOptions);
    customerData.sumInsured = formData.sumInsured;

    this.calculatorService.calculatePremium(customerData)
      .subscribe(
        (result) => {
          var resultInfo = JSON.stringify(result);
          this.calculatedPremium = resultInfo;

        },
        (error) => {
          console.log(error);
        }
      )
  }

  calculatePremium(event) {
    if (!this.profileForm.valid) {
      this.calculatedPremium = '';
      alert("Please provide values for all the mandatory fields");
    }
    else {
      this.calculatePremiumByOccupation(this.profileForm.value);
    }
  }

}
