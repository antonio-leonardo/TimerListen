# Timer Listen
If do you want do add one Timer Listening during on current thread of your application, this class auxiliate this job. TimerListen class has a decople code that can be used with asynchronously or synchronously (by [SynchronizationContext](https://docs.microsoft.com/en-us/dotnet/api/system.threading.synchronizationcontext)) with User Interface.

The approach is very simple: define on method that needs to be executed frequently (for example, between one-one second steps or ten-and-ten seconds steps etc.), like bellow:
```cs
public static void MethodToExecuteFrequently()
{
   System.Windows.Forms.MessageBox.Show("Ends cycle of timer!");
}
```

The instance of TimerListening is define as a field class:
```cs
public static TimerListen listening = new TimerListen(1000, new Action(() => MethodToExecuteFrequently()))
```

And define the starts and the end of listening:
```cs
static void Main()
{
  listening.Start();
  //Batch and long processing to be execute...
  listening.Stop();
}
```

# Concept
The [Timer Listen](https://github.com/antonio-leonardo/TimerListen) class enjoys features of .NET Framework [Timer](https://docs.microsoft.com/en-us/dotnet/api/system.timers.timer) class, that has a pooling thread, based on Rounding Robing Scheduling (https://en.wikipedia.org/wiki/Round-robin_scheduling)

----------------------
## License

[View MIT license](https://github.com/antonio-leonardo/TimerListen/blob/master/LICENSE)
