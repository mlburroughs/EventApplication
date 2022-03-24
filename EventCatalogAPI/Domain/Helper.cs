using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class Helper
    {
        public List<string> RefundPolicyBeforeImmutable { get; set; }

        public ImmutableList<string> RefundPolicies { get; set; }

        public Helper() {

            RefundPolicyBeforeImmutable = new List<string>();
            RefundPolicyBeforeImmutable.Add("Up to 1 day before the event starts");
            RefundPolicyBeforeImmutable.Add("Up to 7 days before the event starts");
            RefundPolicyBeforeImmutable.Add("Up to 30 days before the event starts");
            RefundPolicyBeforeImmutable.Add("On a case-by-case basis");
            RefundPolicyBeforeImmutable.Add("No refunds");

            RefundPolicies = RefundPolicyBeforeImmutable.ToImmutableList();
        }
    }
}
