public class TrafficLight : ITrafficLight
{
    private Light light;

    public TrafficLight(Light light)
    {
        this.light = light;
    }
    public void ChangeLights()
    {
        this.light += 1;
        this.light = (int)this.light > 2 ? 0 : this.light;
    }

    public override string ToString()
    {
        return this.light.ToString();
    }
}