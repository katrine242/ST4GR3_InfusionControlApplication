using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ST4GR3_InfusionControlApplication.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        // UI bruger de nedenstående metoder og lytter efter det ovenstående event ^^
        public virtual bool CanExecute(object parameter) // fortæller om Command kan execute. Hvis denne returnerer false, vil knappen i View disables
        {
            return true; 
            // Når den returnerede value ændres, skal Eventhandleren raises, hvorefter UI vil køre CanExecute()
        }

        public abstract void Execute(object parameter);
        //Klasser som arver fra denne klasse: I denne metode skal der være det som skal ske, når der klikkes på knappen som denne Command er bindet til

        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }


    }
}
