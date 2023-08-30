using HomeworkExercise2;

namespace HomeworkExercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            IView view = new ConsoleView();
            var loops = new Loops();

            var loopController
                   = new LoopController(view, loops);
            loopController.Go();
        }
    }
}