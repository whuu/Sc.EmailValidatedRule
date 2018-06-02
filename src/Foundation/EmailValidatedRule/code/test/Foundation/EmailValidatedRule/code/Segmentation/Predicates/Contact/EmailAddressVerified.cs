using Sitecore.Framework.Rules;
using Sitecore.XConnect.Collection.Model;

namespace Sc.EmailValidatedRule.Segmentation.Predicates.Contact
{
    using Contact = Sitecore.XConnect.Contact;

    /// <summary>
    /// Check if contact primary email is verified
    /// </summary>
    public class EmailAddressVerified : ICondition
    {
        // Evaluates condition for single contact
        public bool Evaluate(IRuleExecutionContext context)
        {
            var contact = context.Fact<Contact>();
            EmailAddressList emails = CollectionModel.Emails(RuleExecutionContextExtensions.Fact<Contact>(context, null));
            return emails?.PreferredEmail == null ? false : emails.PreferredEmail.Validated;
        }
    }
}