namespace HomeworkExercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            IView view = new ConsoleView();
            var stringy = new Stringy();

            var loopController
                   = new StringController(view, stringy);
            loopController.Go();
        }
    }
}