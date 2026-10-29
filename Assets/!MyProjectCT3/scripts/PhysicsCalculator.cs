public static class PhysicsCalculator
{
    public static float CalculateKineticEnergy(float mass, float velocity)
    {
        return 0.5f * mass * velocity * velocity;
    }

    public static float CalculatePotentialEnergy(float mass, float height, float gravity)
    {
        return mass * gravity * height;
    }
}