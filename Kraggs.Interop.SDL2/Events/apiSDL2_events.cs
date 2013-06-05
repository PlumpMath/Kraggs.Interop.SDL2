using System;
using System.Runtime.InteropServices;
using System.Diagnostics;

// mapp to system intptr
using SDL_Window = System.IntPtr;
using SDL_GLContext = System.IntPtr;
using SDL_Surface = System.IntPtr;

namespace Kraggs.Interop.SDL2
{
    public delegate int delSDL2EventFilter(IntPtr UserData, ref SDL2Event Event);

    partial class apiSDL2
    {
        /// <summary>
        /// Pumps the event loop, gathering events from the input devices.
        /// This function updates the event queue and internal input device state.
        /// This should only be run in the thread that sets the video mode.
        /// </summary>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_PumpEvents", CallingConvention = SDL2_CALL)]
        public static extern void PumpEvents();

        /// <summary>
        /// Checks the event queue for messages and optionally returns them.
        /// 
        /// If \c action is ::SDL_ADDEVENT, up to \c numevents events will be added to the back of the event queue.
        /// 
        /// If \c action is ::SDL_PEEKEVENT, up to \c numevents events at the front of the event queue, within the specified minimum and maximum type, will be returned and will not be removed from the queue.
        /// 
        /// If \c action is ::SDL_GETEVENT, up to \c numevents events at the front of the event queue, within the specified minimum and maximum type, will be returned and will be removed from the queue.
        /// 
        /// This function is thread-safe.
        /// </summary>
        /// <param name="events"></param>
        /// <param name="numevents"></param>
        /// <param name="action"></param>
        /// <param name="mintype"></param>
        /// <param name="maxtype"></param>
        /// <returns>The number of events actually stored, or -1 if there was an error.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_PeepEvents", CallingConvention = SDL2_CALL)]
        public static extern int PeepEvents(SDL2Event[] events, int numevents,
              SDL2EventActionEnum action, uint mintype, uint maxtype);
        /// <summary>
        /// Checks the event queue for messages and optionally returns them.
        /// 
        /// If \c action is ::SDL_ADDEVENT, up to \c numevents events will be added to the back of the event queue.
        /// 
        /// If \c action is ::SDL_PEEKEVENT, up to \c numevents events at the front of the event queue, within the specified minimum and maximum type, will be returned and will not be removed from the queue.
        /// 
        /// If \c action is ::SDL_GETEVENT, up to \c numevents events at the front of the event queue, within the specified minimum and maximum type, will be returned and will be removed from the queue.
        /// 
        /// This function is thread-safe.
        /// </summary>
        /// <param name="oneevent"></param>
        /// <param name="one"></param>
        /// <param name="action"></param>
        /// <param name="mintype"></param>
        /// <param name="maxtype"></param>
        /// <returns>The number of events actually stored, or -1 if there was an error.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_PeepEvents", CallingConvention = SDL2_CALL)]
        public static extern int PeepEvents(out SDL2Event oneevent, int one,
              SDL2EventActionEnum action, uint mintype, uint maxtype);

        /// <summary>
        /// Checks to see if certain event types are in the event queue.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_HasEvent", CallingConvention = SDL2_CALL)]
        public static extern int HasEvent(uint type);

        /// <summary>
        /// Checks to see if certain event types are in the event queue.
        /// </summary>
        /// <param name="minType"></param>
        /// <param name="maxType"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_HasEvents", CallingConvention = SDL2_CALL)]
        public static extern int HasEvents(uint minType, uint maxType);

        /// <summary>
        /// This function clears events from the event queue
        /// </summary>
        /// <param name="type"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_FlushEvent", CallingConvention = SDL2_CALL)]
        public static extern void FlushEvent(uint type);

        /// <summary>
        /// This function clears events from the event queue
        /// </summary>
        /// <param name="minType"></param>
        /// <param name="maxType"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_FlushEvents", CallingConvention = SDL2_CALL)]
        public static extern void FlushEvents(uint minType, uint maxType);
        
        /// <summary>
        /// Polls for currently pending events.
        /// </summary>
        /// <param name="Event">If not NULL, the next event is removed from the queue and stored in that area.</param>
        /// <returns>1 if there are any pending events, or 0 if there are none available.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_PollEvent", CallingConvention = SDL2_CALL)]
        public static extern int PollEvent(out SDL2Event Event);

        /// <summary>
        /// Waits indefinitely for the next available event.
        /// </summary>
        /// <param name="Event">If not NULL, the next event is removed from the queue and stored in that area.</param>
        /// <returns>1, or 0 if there was an error while waiting for events.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_WaitEvent", CallingConvention = SDL2_CALL)]
        public static extern int WaitEvent(out SDL2Event Event);

        /// <summary>
        /// Waits until the specified timeout (in milliseconds) for the next available event.
        /// </summary>
        /// <param name="Event">If not NULL, the next event is removed from the queue and stored in that area.</param>
        /// <param name="timeout">The timeout (in milliseconds) to wait for next event.</param>
        /// <returns>1, or 0 if there was an error while waiting for events.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_WaitEventTimeout", CallingConvention = SDL2_CALL)]
        public static extern int WaitEventTimeout(out SDL2Event Event, int timeout);

        /// <summary>
        /// Add an event to the event queue.
        /// </summary>
        /// <param name="Event"></param>
        /// <returns>1 on success, 0 if the event was filtered, or -1 if the event queue was full or there was some other error.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_PushEvent", CallingConvention = SDL2_CALL)]
        public static extern int PushEvent(ref SDL2Event Event);

        /// <summary>
        /// Sets up a filter to process all events before they change internal state and are posted to the internal event queue.
        /// The filter is prototyped as:
        /// <code>
        ///     int SDL_EventFilter(void *userdata, SDL_Event * event);
        /// </code>
        /// If the filter returns 1, then the event will be added to the internal queue.
        /// If it returns 0, then the event will be dropped from the queue, but the internal state will still be updated.  This allows selective filtering of dynamically arriving events.
        /// 
        /// WARNING: Be very careful of what you do in the event filter function, as it may run in a different thread!
        /// 
        /// There is one caveat when dealing with the ::SDL_QUITEVENT event type.  The event filter is only called when the window manager desires to close the application window.  If the event filter returns 1, then the window will be closed, otherwise the window will remain open if possible.
        /// If the quit event is generated by an interrupt signal, it will bypass the internal queue and be delivered to the application at the next event poll.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userdata"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_SetEventFilter", CallingConvention = SDL2_CALL)]
        public static extern void SetEventFilter(delSDL2EventFilter filter, IntPtr userdata);

        /// <summary>
        /// Return the current event filter - can be used to "chain" filters.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userdata"></param>
        /// <returns>If there is no event filter set, this function returns SDL_FALSE.</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_GetEventFilter", CallingConvention = SDL2_CALL)]
        public static extern int GetEventFilter(out delSDL2EventFilter filter, out IntPtr userdata);

        /// <summary>
        /// Add a function which is called when an event is added to the queue.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userdata"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_AddEventWatch", CallingConvention = SDL2_CALL)]
        public static extern void AddEventWatch(delSDL2EventFilter filter, IntPtr userdata);

        /// <summary>
        /// Remove an event watch function added with SDL_AddEventWatch()
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userdata"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_DelEventWatch", CallingConvention = SDL2_CALL)]
        public static extern void DelEventWatch(delSDL2EventFilter filter, IntPtr userdata);

        /// <summary>
        /// Run the filter function on the current event queue, removing any events for which the filter returns 0.
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="userdata"></param>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_FilterEvents", CallingConvention = SDL2_CALL)]
        public static extern void FilterEvents(delSDL2EventFilter filter, IntPtr userdata);

        /// <summary>
        /// This function allows you to set the state of processing certain events.
        /// <list type="bullet">
        /// <item>If \c state is set to ::SDL_IGNORE, that event will be automatically dropped from the event queue and will not event be filtered.</item>
        /// <item>If \c state is set to ::SDL_ENABLE, that event will be processed normally.</item>
        /// <item>If \c state is set to ::SDL_QUERY, SDL_EventState() will return the current processing state of the specified event.</item>
        /// </list>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_EventState", CallingConvention = SDL2_CALL)]
        public static extern byte EventState(SDL2EventTypeEnum type, SDL2EventStateEnum state);

        //// closes we get to a macro
        //[DebuggerNonUserCode()]
        //public static byte GetEventState(SDL2EventTypeEnum type)
        //{
        //    return EventState(type, SDL2EventStateEnum.Query);
        //}

        /// <summary>
        /// This function allocates a set of user-defined events, and returns the beginning event number for that set of events.
        /// </summary>
        /// <param name="numevents"></param>
        /// <returns>If there aren't enough user-defined events left, this function returns (Uint32)-1</returns>
        [DllImport(SDL2_LIBRARY, EntryPoint = "SDL_RegisterEvents", CallingConvention = SDL2_CALL)]
        public static extern uint RegisterEvents(int numevents);

    }
}
