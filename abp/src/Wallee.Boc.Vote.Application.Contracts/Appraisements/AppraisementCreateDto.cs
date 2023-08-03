using System;

namespace Wallee.Boc.Vote.Appraisements
{
    public class AppraisementCreateDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public EvaluationCategory Category { get; set; }

        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
