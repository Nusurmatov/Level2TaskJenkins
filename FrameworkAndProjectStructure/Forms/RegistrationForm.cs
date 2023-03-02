using FrameworkAndProjectStructure.Elements;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class RegistrationForm : BaseForm
    {
        public static By UniqueLocator = By.Id("registration-form-modal");

        private readonly By FirstNameInputLocator = By.Id("firstName");

        private readonly By LastNameInputLocator = By.Id("lastName");

        private readonly By EmailInputLocator = By.Id("userEmail");

        private readonly By AgeInputLocator = By.Id("age");

        private readonly By SalaryInputLocator = By.Id("salary");

        private readonly By DepartmentInputLocator = By.Id("department");

        private readonly By SubmitButtonLocator = By.Id("submit");

        public Input FirstNameInput => new Input(FirstNameInputLocator, "First Name Input");

        public Input LastNameInput => new Input(LastNameInputLocator, "Last Name Input");

        public Input EmailInput => new Input(EmailInputLocator, "Email Input");

        public Input AgeInput => new Input(AgeInputLocator, "Age Input");

        public Input SalaryInput => new Input(SalaryInputLocator, "Salary Input");

        public Input DepartmentInput => new Input(DepartmentInputLocator, "Department Input");

        public Button SubmitButton => new Button(SubmitButtonLocator, "Submit Button");

        public RegistrationForm() : base(UniqueLocator, "Registration Form") { }
    }
}
