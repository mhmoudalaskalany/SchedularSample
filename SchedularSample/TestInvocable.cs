using System;
using System.Threading.Tasks;
using Coravel.Invocable;

namespace SchedulerSample
{
    public class TestInvocable : IInvocable
    {
        public TestInvocable()
        {
            
        }
        public async Task Invoke()
        {
             Console.WriteLine("Hello From Invocable");
        }
    }
}
