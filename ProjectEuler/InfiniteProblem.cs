namespace ProjectEuler;

public abstract class InfiniteProblem : Problem
{
    protected InfiniteProblem(int number, string name) : base(number, name) { }

    public sealed override object Run()
    {
        Console.WriteLine("This problem will run forever, press any key to stop it.");
        Console.WriteLine("This is because the problem requires some form of \"Find all...\" with no upper bound.\n");

        var cts = new CancellationTokenSource();

        var runTask = InternalRunAsync(cts.Token);

        Console.ReadKey();

        Console.WriteLine("\nStopping problem...");
        cts.Cancel();

        try
        {
            return runTask.GetAwaiter().GetResult();
        }
        catch (TaskCanceledException) { }

        return null;
    }

    private async Task<object> InternalRunAsync(CancellationToken cancellationToken)
    {
        await Task.Yield();
        try
        {
            return RunUntilCancelled(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }

    protected abstract object RunUntilCancelled(CancellationToken cancellationToken);
}
