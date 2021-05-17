
using NAudio.Wave;

using NAudio.Dsp;

namespace Synthesizer
{
    class HighPassFilterSampleProvider : ISampleProvider
    {
        private readonly ISampleProvider _source;
        private readonly BiQuadFilter _filter;
        public WaveFormat WaveFormat => _source.WaveFormat;

        public HighPassFilterSampleProvider(ISampleProvider source, int cutOffFrequency = 50, float q = 0.7f)
        {
            _source = source;
            _filter = BiQuadFilter.HighPassFilter(source.WaveFormat.SampleRate, cutOffFrequency, q);
        }
        public int Read(float[] buffer, int offset, int count)
        {

            var samples = _source.Read(buffer, offset, count);
            for (int n = 0; n < samples; n++)
            {
                buffer[offset + n] *= _filter.Transform(buffer[offset + n]);
            }
            return samples;

        }
    }
}
