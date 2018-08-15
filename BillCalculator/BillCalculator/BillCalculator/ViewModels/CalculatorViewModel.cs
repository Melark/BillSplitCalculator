using BillCalculator.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BillCalculator.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
        private int amountOfTimesToSplitBill;
        public int AmountOfTimesToSplitBill
        {
            get => amountOfTimesToSplitBill;
            set
            {
                amountOfTimesToSplitBill = value;
                OnPropertyChanged();
            }
        }

        private double billTotal_ExcludingTip;
        public double BillTotal_ExcludingTip
        {
            get => billTotal_ExcludingTip;
            set
            {
                billTotal_ExcludingTip = value;
                OnPropertyChanged();
            }
        }

        private double billTotal_IncludingTip;
        public double BillTotal_IncludingTip
        {
            get => billTotal_IncludingTip;
            set
            {
                billTotal_IncludingTip = value;
                OnPropertyChanged();
            }
        }


        private double tipPercentage;
        public double TipPercentage
        {
            get => tipPercentage;
            set
            {
                tipPercentage = value;
                OnPropertyChanged();
            }
        }

        private double billSplitTotal;
        public double BillSplitTotal
        {
            get => billSplitTotal;
            set
            {
                billSplitTotal = value;
                OnPropertyChanged();
            }
        }

        private void CalculateSplitOnBillTotal()
        {
            BillTotal_IncludingTip = BillTotal_ExcludingTip + (BillTotal_ExcludingTip * TipPercentage / 100);
            BillSplitTotal = BillTotal_IncludingTip / AmountOfTimesToSplitBill;
        }

        public ICommand CalculateBillCommand
        {
            get {
                return new Command(()=> {
                    CalculateSplitOnBillTotal();
                });
            }
        }
    }
}
