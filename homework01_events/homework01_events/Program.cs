namespace homework01_events

{
    #region AutoResetEvent

    //    internal class Program
    //    {
    //        private static AutoResetEvent Autoevent = new (false);

    //        public static void Foo()
    //        {
    //            using Mutex mutex = new Mutex();

    //            mutex.WaitOne();

    //            for (int i = 0; i < 5; i++)
    //            {
    //                Console.WriteLine($"This is {i} from {Thread.CurrentThread.ManagedThreadId}");
    //            }



    //            Autoevent.Set();
    //            mutex.ReleaseMutex();

    //        }


    //        static void Main(string[] args)
    //        {
    //            Console.WriteLine("Main started");




    //            for (int i = 0; i < 5; i++)
    //            {

    //                Thread thr = new(Foo);

    //                thr.Start();


    //            }


    //            Autoevent.WaitOne();


    //            Console.WriteLine("Main finished");
    //        }
    //    }
    #endregion


    #region ManualResetEvent
    //internal class Program
    //{
    //    public static ManualResetEvent ManualEvent = new ManualResetEvent(false);
    //    public static void Foo()
    //    {

    //        using Mutex mutex = new();
    //        mutex.WaitOne();

    //        for (int i = 0; i < 5; i++)
    //        {

    //            Console.WriteLine($"This is {i} from {Thread.CurrentThread.ManagedThreadId}");

    //        }

    //        ManualEvent.Set();
    //        mutex.ReleaseMutex();

    //    }


    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Main started");



    //        for (int i = 0; i < 5; i++)
    //        {

    //            Thread thr = new(Foo);

    //            thr.Start();


    //        }

    //        ManualEvent.WaitOne();


    //        Console.WriteLine("Main finished");
    //    }
    //}
    #endregion

}









