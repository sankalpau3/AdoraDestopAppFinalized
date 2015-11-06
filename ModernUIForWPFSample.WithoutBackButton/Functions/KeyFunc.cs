using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModernUIForWPFSample.WithoutBackButton.Functions
{
    class KeyFunc
    {

        public bool allowKeywithDot(Key inkey)
        {
            return !IsNumberKey(inkey) && !IsActionKey(inkey) && !isDot(inkey);
        }
        public bool allowKeywithOutDot(Key inkey)
        {
            return !IsNumberKey(inkey) && !IsActionKey(inkey);
        }
        private bool IsNumberKey(Key inKey)
        {
            if (inKey < Key.D0 || inKey > Key.D9)
            {
                if ((inKey < Key.NumPad0 || inKey > Key.NumPad9) || inKey != Key.Decimal || inKey != Key.OemPeriod)
                {
                    return false;
                }
            }
            return true;
        }
        private bool isDot(Key inkey)
        {
            return inkey == Key.OemPeriod || inkey == Key.Decimal;
        }


        private bool IsActionKey(Key inKey)
        {
            return inKey == Key.Delete || inKey == Key.Back || inKey == Key.Tab || inKey == Key.Return || Keyboard.Modifiers.HasFlag(ModifierKeys.Alt);
        }
    }
}
