using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Pages;

public partial class EmployeesDetailsPage : ContentPage
{
    public EmployeesDetailsPage(EmployeeDetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}