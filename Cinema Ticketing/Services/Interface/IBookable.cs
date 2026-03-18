using System;

namespace Cinema_Ticketing.Services.Interface
{
    internal interface IBookable
    {
        bool IsBooked { get; }
        bool Book();
        bool Cancel();
    }
}
