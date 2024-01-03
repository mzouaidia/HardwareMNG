namespace HardwareMNG.App.Pages
{
    public partial class Counter
    {
        private int currentCount;

        private void IncrementCount()
        {
            currentCount++;
        }

        private void DecrementCount()
        {
            currentCount--;
        }

        private void ClearCounter()
        {
            currentCount = 0;
        }
    }
}
