﻿using NAudio.Wave;
using System;

namespace Synthesizer
{
    class ChorusSampleProvider : ISampleProvider
    {
        private const int BufferSize = 8192;

        private readonly ISampleProvider _source;
        private float[] _circularBuffer = new float[BufferSize];
        private int _fillingPointer = 0;
        private float _sweep = 0.0f;
        private float _step = 0.0f;
        private int _minSweepSamples = 0;
        private int _maxSweepSamples = 0;
        private int _sweepSamples = 0;
        private float _rate = 0.2f;
        private int _delaySamples = 22;

        public WaveFormat WaveFormat => _source.WaveFormat;
        private float sweepRate;
        public float SweepRate
        {
            get
            {
                return sweepRate;
            }
            set
            {
                sweepRate = value;
                _rate = (float)Math.Pow(10.0, value / _source.WaveFormat.SampleRate);
                _rate -= 1.0f;
                _rate *= 1.1f;
                _rate += 0.1f;
                SetSweep();
            }
        }
        private float width;
        public float Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                _sweepSamples = (int)Math.Round(value * 0.05 * _source.WaveFormat.SampleRate);
                SetSweep();
            }
        }

        private float delay;
        public float Delay
        {
            get
            {
                return delay;
            }
            set
            {
                delay = value;
                var seconds = Math.Pow(10.0, (double)2.0) / 1000.0;
                _delaySamples = (int)Math.Round(seconds * _source.WaveFormat.SampleRate);
                SetSweep();
            }
        }

        public ChorusSampleProvider(ISampleProvider source)
        {
            _source = source;

            // Defaults
            SweepRate = 0.2f; // 0.0 to 1.0
            Width = 0.3f;     // 0.0 to 1.0; 0.0 means effect is off
            Delay = 0.2f;     // 0.0 to 1.0

            SetSweep();
        }

        public int Read(float[] buffer, int offset, int count)
        {
            var samples = _source.Read(buffer, offset, count);

            if (Width < 0.1f)
            {
                return samples;
            }

            for (var i = 0; i < samples; i++)
            {
                var inputSample = buffer[offset + i];
                _circularBuffer[_fillingPointer] = inputSample;
                _fillingPointer = (_fillingPointer + 1) & (BufferSize - 1);

                var emptyingPointer = (int)(_fillingPointer - _sweep);
                emptyingPointer &= (BufferSize - 1);
                var delayedSample = _circularBuffer[emptyingPointer];

             
                var mixedSignal = 0.5f * inputSample + 0.5f * delayedSample;
                buffer[offset + i] = Constrain(mixedSignal, -0.99f, 0.99f);

            
                _sweep += _step;

                if (_sweep >= _maxSweepSamples || _sweep <= _minSweepSamples)
                {
                    _step = -_step;
                }
            }

            return samples;
        }

        private void SetSweep()
        {
            // Samples per second needed to achieve desired sweep rate...
            _step = _sweepSamples * 2.0f * _rate / _source.WaveFormat.SampleRate;

            _minSweepSamples = _delaySamples;
            _maxSweepSamples = _delaySamples + _sweepSamples;

            // Set starting _sweep value to mid-range...
            _sweep = (_minSweepSamples + _maxSweepSamples) / 2.0f;
        }

        private float Constrain(float input, float minimum, float maximum)
        {
            if (input > maximum)
            {
                return maximum;
            }
            else if (input < minimum)
            {
                return minimum;
            }
            else
            {
                return input;
            }
        }
    }
}
