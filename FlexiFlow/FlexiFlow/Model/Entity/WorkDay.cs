namespace FlexiFlow;

public class WorkDay
{ 
    public DateTime DayOfWork { get; private set; }  
    public DateTime HoursWorked { get; private set; }
    public double BreakTime { get; private set; }

    public WorkDay(
        DateTime dayOfWork,
        DateTime hoursWorked,
        double breakTime)
    {
        DayOfWork = dayOfWork;
        HoursWorked = hoursWorked;
        BreakTime = breakTime;
    }
}