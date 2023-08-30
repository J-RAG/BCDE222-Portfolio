namespace HomeworkExercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*IView view = new ConsoleView();
            var conditionals = new Conditonals();

            var conditionalController
                   = new ConditionalController(view, conditionals);
            conditionalController.Go();*/

            IView view = new ConsoleView();
            var loops = new Loops();

            var loopController
                   = new LoopController(view, loops);
            loopController.Go();
        }
    }
}