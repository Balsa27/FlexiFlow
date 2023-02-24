namespace FlexiFlow;

public class Preference
{
    public int NumberOfBreaks { get; set; }
    public int EndOfWorkDay { get; set; }
    public double BreakLenght { get; set; }
    public bool AutoFocus { get; set; }

    public Preference() { }

    public Preference(
        int numberOfBreaks,
        int endOfWorkDay,
        double breakLenght,
        bool autoFocus)
    {
        NumberOfBreaks = numberOfBreaks;
        EndOfWorkDay = endOfWorkDay;
        BreakLenght = breakLenght;
        AutoFocus = autoFocus;
    }
}