using OpenQA.Selenium;
using ProjectStructure.Driver;
using SeleniumExtras.WaitHelpers;

namespace ProjectStructure.Pages
{
    public class PrivacyPolicyPage : BasePage
    {
        private readonly By PageNameLocator = By.ClassName("page_name");

        private readonly By SwitchLanguagElementsListLocator = By.Id("languages");

        private readonly By SupportedLanguagesLocator = By.XPath("//*[@id='languages']/child::a");

        private readonly By RevisionDateLocator = By.XPath("//*[@id='newsColumn']/child::i[contains(text(), 'Revision')]");

        public PrivacyPolicyPage() : base() { }

        public IWebElement PageName => base.WaitAndFindElement(PageNameLocator);

        public IWebElement SwitchLanguageElementsList => base.WaitAndFindElement(SwitchLanguagElementsListLocator);

        public IWebElement RevisionDate => base.WaitAndFindElement(RevisionDateLocator);
    
        public IReadOnlyCollection<IWebElement> SupportedLanguages
        {
            get
            {
                base.Wait.Until(ExpectedConditions.ElementExists(SupportedLanguagesLocator));
                return Singleton.Driver().FindElements(SupportedLanguagesLocator);
            }
        }

        public bool AreAllSupportedLanguagesDisplayed(string[] supportedLanguages)
        {
            bool IsAllLanguagesDisplayed = false;

            foreach (var element in SupportedLanguages) 
            { 
                for (int i = 0; i < supportedLanguages.Length; i++)
                {
                    if (element.GetAttribute("href").Contains(supportedLanguages[i]))
                    {
                        IsAllLanguagesDisplayed = true; 
                        break;
                    }
                    else
                    {
                        IsAllLanguagesDisplayed = false;
                    }
                }
            }

            return IsAllLanguagesDisplayed;
        }
    }
}
