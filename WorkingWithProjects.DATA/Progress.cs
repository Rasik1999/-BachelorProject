namespace WorkingWithProjects.DATA
{
    public class Progress
    {
        public int ProgressId { get; set; }

        public decimal Value { get; set; }

        public decimal DesiredValue { get; set; }

        public decimal PercentageOfCompletion { get; set; }

        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}
