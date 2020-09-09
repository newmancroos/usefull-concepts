# usefull-concepts
<p>
	<h2>Fire and Forget</h2><br>
	Some time we need to fire a function and wether it is sucessful or not we want to simple forget and do the some other work(Fire and Forget). There are some utils are there in market (ex. Hangfire) to do the work, but some time time we want to use a simple function to log some message. We can use <br>
	<pre>
		Task.Run(() =>{...});
	</pre>
	to run a background operation. <br>
	If everything goes well it is good butif you get any exceptions, we need to check task.Exception directly to know why it faild or you can await the task or use a blokcing call such as <b>Result or wait()</b> to get the exception. If you don't watch the result of the task, the exception will eventually be raised using <b>TaskScheduler.UbobservedTaskexception.<br>
	Some time you don't want to care about wether it is suceed or fail. in that case we can use We can write an extension method to Task to handle UnobservedTaskException.
	<pre>
	public static class TaskExtensions
	{
		public static void Forget(this Task task)
		{
			// note: this code is inspired by a tweet from Ben Adams: https://twitter.com/ben_a_adams/status/1045060828700037125
			// Only care about tasks that may fault (not completed) or are faulted,
			// so fast-path for SuccessfullyCompleted and Canceled tasks.
			if (!task.IsCompleted || task.IsFaulted)
			{
				// use "_" (Discard operation) to remove the warning IDE0058: Because this call is not awaited, execution of the current method continues before the call is completed
				// https://docs.microsoft.com/en-us/dotnet/csharp/discards#a-standalone-discard
				_ = ForgetAwaited(task);
			}
			// Allocate the async/await state machine only when needed for performance reason.
			// More info about the state machine: https://blogs.msdn.microsoft.com/seteplia/2017/11/30/dissecting-the-async-methods-in-c/
			async static Task ForgetAwaited(Task task)
			{
				try
				{
					// No need to resume on the original SynchronizationContext, so use ConfigureAwait(false)
					await task.ConfigureAwait(false);
				}
				catch
				{
					// Nothing to do here
				}
			}
		}
	}
	Task.Run(() => {...}).Forget();
	</pre>
	Article Link : https://www.meziantou.net/fire-and-forget-a-task-in-dotnet.htm
</p>