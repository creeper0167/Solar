using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar.Application.Services.Service
{
    public class BackgroundJobTest : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Task is in progress...");
            return Task.CompletedTask;
        }
    }
}
