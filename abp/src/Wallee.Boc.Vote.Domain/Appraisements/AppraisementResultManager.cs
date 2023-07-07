using System.Collections.Generic;
using System.Text.RegularExpressions;
using Volo.Abp;
using Volo.Abp.Domain.Services;
using Wallee.Boc.Vote.AppraisementResults;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementResultManager : DomainService
    {
        public AppraisementResultManager(
            IAppraisementResultRepository appraisementResultRepository)
        {
            AppraisementResultRepository = appraisementResultRepository;
        }
        public IAppraisementResultRepository AppraisementResultRepository { get; }
    }
}
