namespace HomeworkExercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            IView view = new ConsoleView();
            var methods = new Methods();

            var loopController
                   = new MethodsController(view, methods);
            loopController.Go();
        }
    }
}