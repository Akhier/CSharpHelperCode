namespace CSharpHelperCode
{
    static public class Helper {
        /// <summary>
        /// Takes T value, int width, and int height then returns T[,]
        /// </summary>
        /// <typeparam name="T">The type of the array to return</typeparam>
        /// <param name="value">A value of type T to fill array</param>
        /// <returns>Returns an array T[width,height] filled with value</returns>
        static public T[,] init2dArrayToValue<T>(T value, int width, int height) {
            var output = new T[width, height];
            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    output[x, y] = value;
                }
            }
            return output;
        }
    }
}