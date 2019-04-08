# Timer Listen
If do you want do add one Timer Listening during on current thread of your application, this class auxiliate this job. TimerListen class has a decople code that can be used with asynchrnouly or synchronouly with User Interface.

The approach is very simple: define on method that needs to be executed frequently (between one-one second or ten and ten seconds), like bellow:
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

----------------------
## License

[View MIT license](https://github.com/antonio-leonardo/TimerListen/blob/master/LICENSE)
