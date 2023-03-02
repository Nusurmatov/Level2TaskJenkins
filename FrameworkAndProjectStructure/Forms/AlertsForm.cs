using FrameworkAndProjectStructure.Elements;
using OpenQA.Selenium;

namespace FrameworkAndProjectStructure.Forms
{
    public class AlertsForm : BaseForm
    {
        public static By UniqueLocator = By.Id("javascriptAlertsWrapper");

        private readonly By AlertButtonLocator = By.Id("alertButton");

        private readonly By ConfirmButtonLocator = By.Id("confirmButton");

        private readonly By ConfirmResultLabelLocator = By.Id("confirmResult");

        private readonly By PromptButtonLocator = By.Id("promtButton");

        private readonly By PromptResultLabelLocator = By.Id("promptResult");

        public Button AlertButton => new Button(AlertButtonLocator, "Click me - Alert Button");

        public Button ConfirmButton => new Button(ConfirmButtonLocator, "Click me - Confirm Button");

        public Button PromptButton => new Button(PromptButtonLocator, "Click me - Prompt Button");

        public Label ConfirmResultLabel => 
            new Label(ConfirmResultLabelLocator, "You selected Ok/Cancel - Confirm Result Label");

        public Label PromptResultLabel => 
            new Label(PromptResultLabelLocator, "You entered ### - Prompt Result Label");

        public AlertsForm() : base(UniqueLocator, "Alerts Form") { }
    }
}
