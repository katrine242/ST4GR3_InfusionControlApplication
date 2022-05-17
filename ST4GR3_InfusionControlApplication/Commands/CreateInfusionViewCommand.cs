using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DTO_Library;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Exception;
using ICA_BusinessLogicLayer.Services;
using ST4GR3_InfusionControlApplication.ViewModels;

namespace ST4GR3_InfusionControlApplication.Commands
{
    public class CreateInfusionViewCommand : CommandBase
    {
       private readonly ViewModelCreateInfusion _viewModelCreateInfusion;
       private readonly InfusionOverview _infusionOverview;
       private readonly NavigationService _menuViewNavigationService;
       private new DTO_InfusionPlan _infusionPlanDTO;
       private new Medicine _medicine;

       public CreateInfusionViewCommand(ViewModelCreateInfusion viewModelCreateInfusion, InfusionOverview infusionOverview, NavigationService menuViewNavigationService)
       {
          _viewModelCreateInfusion = viewModelCreateInfusion;
          _infusionOverview = infusionOverview;
          _menuViewNavigationService = menuViewNavigationService;
          _viewModelCreateInfusion.PropertyChanged += OnViewModelPropertyChanged;

       }


       public override bool CanExecute(object parameter)
       {
          return !string.IsNullOrEmpty(_viewModelCreateInfusion.Patient)&& _viewModelCreateInfusion.CPR>0 &&_viewModelCreateInfusion.Height>0&&_viewModelCreateInfusion.Weight>0&& !string.IsNullOrEmpty(_viewModelCreateInfusion.Medicine)&&_viewModelCreateInfusion.BatchID>0&&_viewModelCreateInfusion.MachineID>0 && base.CanExecute(parameter);
       }
      public override void Execute(object parameter)
      {
         
         try
         {
            InfusionPlan infusionPlan =
               new InfusionPlan(
                  new Medicine().GetMedicine(_infusionOverview.Configlist, _viewModelCreateInfusion.Medicine),_viewModelCreateInfusion.MachineID,_viewModelCreateInfusion.BatchID,_viewModelCreateInfusion.CPR,_viewModelCreateInfusion.Weight,_viewModelCreateInfusion.Patient);
            _infusionOverview.CreateInfusionPlan(infusionPlan);
            _menuViewNavigationService.Navigate();

         }
         catch (InvalidMedicineNameConflictException ex)
         {
            MessageBox.Show("Medicin ikke tilgængeligt","Fejlmeddelelse", MessageBoxButton.OK,MessageBoxImage.Error);
         }


       }

      private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
      {
         if (e.PropertyName == nameof(ViewModelCreateInfusion.Patient)|| e.PropertyName == nameof(ViewModelCreateInfusion.CPR)||e.PropertyName == nameof(ViewModelCreateInfusion.Height)|| e.PropertyName == nameof(ViewModelCreateInfusion.Weight)|| e.PropertyName == nameof(ViewModelCreateInfusion.Medicine)|| e.PropertyName == nameof(ViewModelCreateInfusion.BatchID)|| e.PropertyName == nameof(ViewModelCreateInfusion.MachineID))
         {
            OnCanExecutedChanged();
         }
      }


   }


}

  
