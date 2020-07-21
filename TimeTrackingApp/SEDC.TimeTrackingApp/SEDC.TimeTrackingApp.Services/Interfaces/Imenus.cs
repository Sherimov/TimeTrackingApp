using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.TimeTrackingApp.Services.Interfaces
{
    public interface Imenus
    {
        int MenuChoice(int range);
        int LogInOrRegisterMenu();
        int MainMenu();
        int TrackMenu();
        int ExerciseMenu();
        int ReadingMenu();
        int WorkingMenu();
        int StatsMenu();
        int AccManagement();
    }
}
