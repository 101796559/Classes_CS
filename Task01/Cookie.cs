namespace Task01
{
    public class Cookie
    {
        public class Color {
            public int[] rgb;
            public string name;
            public Color(int[] rgb, string name) {
                this.rgb = rgb;
                this.name = name;
            }
        }

        public int weight;
        public string shape;
        public Color color;

        public Cookie(int weight, string shape, int[] colorRgb, string colorName) {
            this.weight = weight;
            this.shape = shape;
            this.color = new Color(colorRgb, colorName);
        }   
    }
}