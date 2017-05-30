
namespace HowToCopyEventHandlers {
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using BF = System.Reflection.BindingFlags;

    public class CopyEventHandlers {
        /// <summary>       
        /// We use this field to hold some sort of mapping between the Control class's inner field's name that 
        /// the .NET Framework uses as a key to hold handlers attached to an event and the name of d event.
        /// </summary>
        private readonly Dictionary<string, string> _keyEventNameMapping = null;

        public CopyEventHandlers() {            
            _keyEventNameMapping = new Dictionary<string, string>{
                {"EventAutoSizeChanged", "AutoSizeChanged"},
                {"EventBackColor", "BackColorChanged"},
                {"EventBackgroundImage", "BackgroundImageChanged"},
                {"EventBackgroundImageLayout", "BackgroundImageLayoutChanged"},
                {"EventBindingContext", "BindingContextChanged"},
                {"EventCausesValidation", "CausesValidationChanged"},
                {"EventClick", "Click"},
                {"EventClientSize", "ClientSizeChanged"},
                {"EventContextMenu", "ContextMenuChanged"},
                {"EventContextMenuStrip", "ContextMenuStripChanged"},
                {"EventCursor", "CursorChanged"},
                {"EventDock", "DockChanged"},
                {"EventDoubleClick", "DoubleClick"},
                {"EventDragLeave", "DragLeave"},
                {"EventEnabled", "EnabledChanged"},
                {"EventEnter", "Enter"},
                {"EventFont", "FontChanged"},
                {"EventForeColor", "ForeColorChanged"},
                {"EventGotFocus", "GotFocus"},
                {"EventHandleCreated", "HandleCreated"},
                {"EventHandleDestroyed", "HandleDestroyed"},
                {"EventLeave", "Leave"},
                {"EventLocation", "LocationChanged"},
                {"EventLostFocus", "LostFocus"},
                {"EventMarginChanged", "MarginChanged"},
                {"EventMouseCaptureChanged", "MouseCaptureChanged"},
                {"EventMouseEnter", "MouseEnter"},
                {"EventMouseHover", "MouseHover"},
                {"EventMouseLeave", "MouseLeave"},
                {"EventMove", "Move"},
                {"EventPaddingChanged", "PaddingChanged"},
                {"EventParent", "ParentChanged"},
                {"EventRegionChanged", "RegionChanged"},
                {"EventResize", "Resize"},
                {"EventRightToLeft", "RightToLeftChanged"},
                {"EventSize", "SizeChanged"},
                {"EventStyleChanged", "StyleChanged"},
                {"EventSystemColorsChanged", "SystemColorsChanged"},
                {"EventTabIndex", "TabIndexChanged"},
                {"EventTabStop", "TabStopChanged"},
                {"EventText", "TextChanged"},
                {"EventValidated", "Validated"},
                {"EventVisible", "VisibleChanged"},
            };
        }

        public Dictionary<string, string> KeyEventNameMapping {
            get { return _keyEventNameMapping; }
        }

        /// <summary>
        /// Use this method to get a data structure that contains the name of the all events 
        /// that have handlers attached, the inner key that .NET use to point to those handlers and the
        /// list of listeners (the handlers themselves).
        /// </summary>
        /// <param name="ctrl">Control del cual queremos extraer todos los handlers.</param>
        /// <returns></returns>
        public Dictionary<string, Dictionary<object, Delegate[]>> GetHandlersFrom(Control ctrl) {

            var ctrlEventsCollection = (EventHandlerList)typeof(Control).GetProperty("Events", 
                BF.GetProperty | BF.NonPublic | BF.Instance).GetValue(ctrl, null);
            
            var headInfo = typeof(EventHandlerList).GetField("head", BF.Instance | BF.NonPublic);

            var handlers = BuildList(headInfo, ctrlEventsCollection);

            var eventName = GetEventNameFromKey(ctrl, handlers.First().Key);

            //TODO: use key value pair.
            var result = new Dictionary<string, Dictionary<object, Delegate[]>> { { eventName, handlers } };

            return result;
        }       

        /// <summary>
        /// Returns the event's name based on the specified key that 
        /// the .NET Framework use to holds the events handlers.
        /// </summary>
        /// <param name="ctrl">Control</param>
        /// <param name="key">The key (instance) that holds the handlers.</param>
        /// <returns>Event's name mapped to the supplied key.</returns>
        private string GetEventNameFromKey(Control ctrl, object key) {

            foreach (var eventKey in KeyEventNameMapping.Keys) {
                var fieldInfo = typeof(Control).GetField(eventKey, BF.GetField | BF.Static | BF.NonPublic | BF.DeclaredOnly);
                if (fieldInfo != null) {
                    var tmpkey = fieldInfo.GetValue(ctrl);
                    if (tmpkey == key)
                        return KeyEventNameMapping[eventKey];
                }
            }

            return null;
        }

        //**************************************************************************************************************
        //Code borrowed from StackOverflow
        //http://stackoverflow.com/questions/91778/how-to-remove-all-event-handlers-from-a-control
        private Dictionary<object, Delegate[]> BuildList(FieldInfo headInfo, object eventHandlersList) {
            var handlers = new Dictionary<object, Delegate[]>();
            object head = headInfo.GetValue(eventHandlersList);
            if (head != null) {
                Type listEntryType = head.GetType();
                FieldInfo delegateInfo = listEntryType.GetField("handler", BF.Instance | BF.NonPublic);
                FieldInfo currentKeyInfo = listEntryType.GetField("key", BF.Instance | BF.NonPublic);
                FieldInfo nextKeyInfo = listEntryType.GetField("next", BF.Instance | BF.NonPublic);
                handlers = BuildListWalk(handlers, head, delegateInfo, currentKeyInfo, nextKeyInfo);
            }
            return handlers;
        }

        private Dictionary<object, Delegate[]> BuildListWalk(Dictionary<object, Delegate[]> dict, object entry, FieldInfo delegateInfo, FieldInfo keyInfo, FieldInfo nextKeyInfo) {
            if (entry != null) {
                var del = (Delegate)delegateInfo.GetValue(entry);
                object key = keyInfo.GetValue(entry);
                object next = nextKeyInfo.GetValue(entry);

                if (del != null) {
                    Delegate[] listeners = del.GetInvocationList();
                    if (listeners.Length > 0) {
                        dict.Add(key, listeners);
                    }
                }
                if (next != null) {
                    dict = BuildListWalk(dict, next, delegateInfo, keyInfo, nextKeyInfo);
                }
            }
            return dict;
        }
        //**************************************************************************************************************
    }
}