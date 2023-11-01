using System.IO;
using System.Media;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace WavFileTest
{
    class Program
    {
        public int x;
        static void Main(string[] args)
        {
            BallAnimation();
            var channels = 1;
            var sample_rate = 32000;  // samples per second
            var bits_per_sample = 8;
            int iterations = 4;  // number of times you want each algorithm to play
            int secondsPerIteration = 45000 / sample_rate;  // duration of each play in seconds

            var singleIterationDataLength = sample_rate * secondsPerIteration;
            var totalDataLength = singleIterationDataLength * iterations * 2; // times 2 for two types of algorithm
            var data = new byte[totalDataLength];

            for (int i = 0; i < iterations; ++i)
            {
                // first algorithm
                for (var t = 0; t < singleIterationDataLength; t++)
                
                    data[i * singleIterationDataLength + t] = (byte)(-(3 * t & t >> 13 & t >> 6) * t >> 7);
                


            }
  
            for (int i = iterations; i < iterations * 2; ++i)
            {
                // second algorithm
                for (var t = 0; t < singleIterationDataLength; t++)
                    data[i * singleIterationDataLength + t] = (byte)((t * (t >> 57 | t >> 9) & 44 & t >> 8 ^ (t & t >> 13 | t >> 6)));
            }
           

            CreateAndPlayWav(data, channels, sample_rate, bits_per_sample);
            Thread.Sleep(200);
            PT2();

        }
       public static async Task BallAnimation()
        {
            await Task.Run(() =>
            {
                int consoleWidth = 50;
                int consoleHeight = 20;
                int ballX = consoleWidth / 2;
                int ballY = consoleHeight / 2;
                int ballSpeedX = 1;
                int ballSpeedY = 1;
                int i = 0; 
                while (true)
                {

                    Console.Clear();
                    i++;
                    
                    // Update ball position
                    ballX += ballSpeedX;
                    ballY += ballSpeedY;

                    // Reflect ball if it hits the boundaries
                    if (ballX <= 0 || ballX >= consoleWidth - 1)
                    {
                        ballSpeedX *= -1;
                    }
                    if (ballY <= 0 || ballY >= consoleHeight - 1)
                    {
                        ballSpeedY *= -1;
                    }
                    //Change color of text
                    if (i == 1)
                        Console.ForegroundColor = ConsoleColor.Red;
                    if (i == 2)
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    if (i == 3)
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (i == 4)
                        Console.ForegroundColor = ConsoleColor.Blue;
                    if (i == 5)
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    if (i == 6)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        i = 0;
                    }
                    // Draw ball at current position
                    Console.SetCursorPosition(ballX, ballY);
                    Console.CursorVisible = false;
                    Console.Write("O", Console.ForegroundColor, Console.CursorVisible);
                    Console.SetWindowSize(50, 20);
                    // Delay for a short period to control the animation speed
                    Thread.Sleep(10);
                }
            });
        }
        static void PT2()
        {
            var channels = 1;
            var sample_rate = 32000;
            var bits_per_sample = 8;
            int iterations = 4;
            int secondsPerIteration = 40000 / sample_rate;

            var singleIterationDataLength = sample_rate * secondsPerIteration;
            var totalDataLength = singleIterationDataLength * iterations * 7; //defines length of data
                                                                              //based on # of measures*4 (iterations)
                                                                              //and total length
            var data = new byte[totalDataLength];
            //Measures 1-4
            for (int i = 0; i < iterations; ++i)
            {
                for (var t = 0; t < singleIterationDataLength; t++)
                {
                    // generate both sounds
                    var sound1 = (byte)(-(3 * t & t >> 3 & t >> 6) * t >> 7);
                    var sound2 = (byte)(-t * (t >> 2 | t >> 4 | t >> 2 | t >> 6 | t >> 7) - t * 2);

                    // combine sounds and adjust volume
                    var combinedSound = (sound1 + (sound2 * 2)) / 2;
                    data[i * singleIterationDataLength + t] = (byte)(Math.Min(byte.MaxValue, combinedSound / 2 + 127));
                }
            }
            //Measures 4-8
            for (int i = iterations; i < iterations * 2; ++i)
            {
                for (var t = 0; t < singleIterationDataLength; t++)
                {
                    // generate both sounds
                    var sound1 = (byte)(t * (0xCA98 >> (t >> 10 & 14) & 15) | t >> 8 / 2);
                    var sound2 = (byte)(-t * (t >> 2 | t >> 4 | t >> 2 | t >> 6 | t >> 7) - t * 2);

                    // combine sounds and adjust volume
                    var combinedSound = (sound1 + (sound2 * 2)) / 2;
                    data[i * singleIterationDataLength + t] = (byte)(Math.Min(byte.MaxValue, combinedSound / 2 + 127));
                }
            }
            //Measures 8-12
            for (int i = iterations * 2; i < iterations * 3; ++i)
            {
                for (var t = 0; t < singleIterationDataLength; t++)
                {
                    // generate both sounds
                    var sound1 = (byte)(t * (0xCA98 >> (t >> 10 & 14) & 15) | t >> 8 / 3);
                    var sound2 = (byte)(-t * (t >> 2 | t >> 4 | t >> 2 | t >> 6 | t >> 7) - t * 2);

                    // combine sounds and adjust volume
                    var combinedSound = (sound1 + (sound2 * 2)) / 2;
                    data[i * singleIterationDataLength + t] = (byte)(Math.Min(byte.MaxValue, combinedSound / 2 + 127));
                }
            }
            //Measures 12-16
            for (int i = iterations * 3; i < iterations * 4; ++i)
            {
                for (var t = 0; t < singleIterationDataLength; t++)
                {
                    // generate both sounds
                    var sound1 = (byte)(-(3 * t & t >> 3 & t >> 6) * t >> 7);
                    var sound2 = (byte)(t * (0xCA98 >> (t >> 10 & 14) & 15) | t >> 8 / 6);
                    var sound3 = (byte)(-t * (t >> 2 | t >> 7 | t >> 8 | t >> 6 | t >> 7) - t * 2);

                    // combine sounds and adjust volume
                    var combinedSound = (sound1 + sound2 + (sound3 * 3)) / 2;
                    data[i * singleIterationDataLength + t] = (byte)(Math.Min(byte.MaxValue, combinedSound / 2 + 127));
                }
            }
            //Measures 16-20
            for (int i = iterations * 4; i < iterations * 5; ++i)
            {
                for (var t = 0; t < singleIterationDataLength; t++)
                {
                    // generate both sounds
                    var sound1 = (byte)(-(3 * t & t >> 3 & t >> 6) * t >> 7);
                    var sound2 = (byte)(t * (1 + (t >> 10) * (43 + 2 * (t >> 15 - (t >> 16) % 13) % 8) % 8) * (1 + (t >> 14) % 4) * 33);
                    var sound3 = (byte)(-t * (t >> 2 | t >> 7 | t >> 8 | t >> 6 | t >> 7) - t * 2);

                    // combine sounds and adjust volume
                    var combinedSound = (sound1 * 2 + sound2 + (sound3 * 3)) / 2;
                    data[i * singleIterationDataLength + t] = (byte)(Math.Min(byte.MaxValue, combinedSound / 2 + 127));
                }
            }
            //Measures 20-24
            for (int i = iterations * 5; i < iterations * 6; ++i)
            {
                for (var t = 0; t < singleIterationDataLength; t++)
                {
                    // generate both sounds
                    var sound2 = (byte)(t * (1 + (t >> 10) * (86 + 2 * (t >> 15 - (t >> 16) % 13) % 8) % 8) * (1 + (t >> 14) % 4));
                    var sound3 = (byte)(-t * (t >> 2 | t >> 7 | t >> 8 | t >> 6 | t >> 7) - t * 2);

                    // combine sounds and adjust volume
                    var combinedSound = (sound2 + sound3) / 2;
                    data[i * singleIterationDataLength + t] = (byte)(Math.Min(byte.MaxValue, combinedSound / 2 + 127));
                }


            }
            //24-32
            for (int i = iterations * 6; i < iterations * 7; ++i)
            {
           
                    // first algorithm
                    for (var t = 0; t < singleIterationDataLength; t++)
                {
                    var sound1 = (byte)(t * ((t >> 12 | t >> 8) & 32 | 16 / 2 & t >> 4) / 2);
                    var combinedSound = (sound1) / 2;
                    data[i * singleIterationDataLength + t] = (byte)(Math.Min(byte.MaxValue, combinedSound / 2 + 127));
                }

            }


            CreateAndPlayWav(data, channels, sample_rate, bits_per_sample);
            Thread.Sleep(300);
            PT3();

        }
        static void PT3()
        {
            var channels = 1;
            var sample_rate = 32000;  // samples per second
            var bits_per_sample = 8;
            int iterations = 1;  // number of times you want each algorithm to play
            int secondsPerIteration = 1080000 / sample_rate;  // duration of each play in seconds

            var singleIterationDataLength = sample_rate * secondsPerIteration;
            var totalDataLength = singleIterationDataLength * iterations; // times 2 for two types of algorithm
            var data = new byte[totalDataLength];

            //Measures 32
            for (int i = 0; i < iterations; ++i)
            {
                for (var t = 0; t < singleIterationDataLength; t++)
                {
                    // generate both sounds
                    var sound2 = (byte)(t * (1 + (t >> 10) * (86 + 2 * (t >> 15 - (t >> 16) % 13) % 8) % 8) * (1 + (t >> 14) % 4));
                    var sound3 = (byte)(-t * (t >> 2 | t >> 7 | t >> 8 | t >> 6 | t >> 7) - t * 2);

                    // combine sounds and adjust volume
                    var combinedSound = (sound2 + sound3) / 2;
                    data[i * singleIterationDataLength + t] = (byte)(Math.Min(byte.MaxValue, combinedSound / 2 + 127));
                }


            }


            CreateAndPlayWav(data, channels, sample_rate, bits_per_sample);
            Thread.Sleep(600);
   
            PT4();
        }
        static void PT4()
        {
            var channels = 1;
            var sample_rate = 32000;  // samples per second
            var bits_per_sample = 8;
            int iterations = 1;  // number of times you want each algorithm to play
            int secondsPerIteration = 64000 / sample_rate;  // duration of each play in seconds

            var singleIterationDataLength = sample_rate * secondsPerIteration;
            var totalDataLength = singleIterationDataLength * iterations * 2;
            var data = new byte[totalDataLength];

            //Measures 32
            for (int i = 0; i < iterations; ++i)
            {
                // first algorithm
                for (var t = 0; t < singleIterationDataLength; t++)
                    data[i * singleIterationDataLength + t] = (byte)(-(3 * t & t >> 13 & t >> 6) * t >> 7);
            }

            CreateAndPlayWav(data, channels, sample_rate, bits_per_sample);
        }

        static void CreateAndPlayWav(byte[] data, int channels, int sample_rate, int bits_per_sample)
        {
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);

                writer.Write("RIFF".ToCharArray());  // chunk id
                writer.Write((UInt32)0);             // chunk size
                writer.Write("WAVE".ToCharArray());  // format

                writer.Write("fmt ".ToCharArray());  // chunk id
                writer.Write((UInt32)16);            // chunk size
                writer.Write((UInt16)1);             // audio format

                writer.Write((UInt16)channels);
                writer.Write((UInt32)sample_rate);
                writer.Write((UInt32)(sample_rate * channels * bits_per_sample / 8)); // byte rate
                writer.Write((UInt16)(channels * bits_per_sample / 8));               // block align
                writer.Write((UInt16)bits_per_sample);

                writer.Write("data".ToCharArray());

                writer.Write((UInt32)(data.Length * channels * bits_per_sample / 8));

                foreach (var elt in data) writer.Write(elt);

                writer.Seek(4, SeekOrigin.Begin);                     // seek to header chunk size field
                writer.Write((UInt32)(stream.Length - 8)); // chunk size

                stream.Seek(0, SeekOrigin.Begin);

                new SoundPlayer(stream).PlaySync();
                writer.Write("data".ToCharArray());
            }
        }
    }
}