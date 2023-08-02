using System;

namespace Wallee.Boc.Vote.Appraisements
{
    public class GetAppraisementQrcodeDto
    {
        public Guid AppraisementId { get; set; }
        public string RuleName { get; set; } = default!;
    }
}
