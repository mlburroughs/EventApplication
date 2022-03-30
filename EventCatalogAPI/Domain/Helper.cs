using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public static class Helper
    {
        public static List<string> RefundPolicyBeforeImmutable { get; set; }

        public static ImmutableList<string> RefundPolicies { get; set; }

        public static ImmutableList<string> Refunds() {

            RefundPolicyBeforeImmutable = new List<string>();
            RefundPolicyBeforeImmutable.Add("Up to 1 day before the event starts");
            RefundPolicyBeforeImmutable.Add("Up to 7 days before the event starts");
            RefundPolicyBeforeImmutable.Add("Up to 30 days before the event starts");
            RefundPolicyBeforeImmutable.Add("On a case-by-case basis");
            RefundPolicyBeforeImmutable.Add("No refunds");
            RefundPolicyBeforeImmutable.Add("N/A");

            RefundPolicies = RefundPolicyBeforeImmutable.ToImmutableList();
            return RefundPolicies;
        }
    }
}
