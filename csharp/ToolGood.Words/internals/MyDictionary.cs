﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolGood.Words.internals
{
    public class MyDictionary
    {
        private int[] _keys;
        private int[] _values;
        private int last;
        public MyDictionary()
        {
            last = -1;
        }

        public int[] Keys {
            get {
                return _keys;
            }
        }

        public int[] Values {
            get {
                return _values;
            }
        }

        public void SetDictionary(Dictionary<int, int> dict)
        {
            _keys = dict.Select(q => q.Key).ToArray();
            _values = dict.Select(q => q.Value).ToArray();
            last = _keys.Length - 1;
        }


        public bool TryGetValue(int key, out int value)
        {
            if (last == -1) {
                value = 0;
                return false;
            }
            if (_keys[0] == key) {
                value = _values[0];
                return true;
            }
            if (_keys[last] == key) {
                value = _values[last];
                return true;
            }
            var left = 0;
            var right = last;
            while (left + 1 < right) {
                int mid = (left + right) / 2;
                int d = _keys[mid] - key;

                if (d == 0) {
                    value = _values[mid];
                    return true;
                } else if (d > 0) {
                    right = mid;
                } else {
                    left = mid;
                }
            }
            value = 0;
            return false;
        }



    }
}