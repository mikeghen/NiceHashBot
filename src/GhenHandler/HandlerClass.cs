using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net; // For generating HTTP requests and getting responses.
using NiceHashBotLib; // Include this for Order class, which contains stats for our order.
using Newtonsoft.Json; // For JSON parsing of remote APIs.

public class HandlerClass
{
    /// <summary>
    /// This method is called every 0.5 seconds.
    /// </summary>
    /// <param name="OrderStats">Order stats - do not change any properties or call any methods. This is provided only as read-only object.</param>
    /// <param name="MaxPrice">Current maximal price. Change this, if you would like to change the price.</param>
    /// <param name="NewLimit">Current speed limit. Change this, if you would like to change the limit.</param>
    public static void HandleOrder(ref Order OrderStats, ref double MaxPrice, ref double NewLimit)
    {
        // Following line of code makes the rest of the code to run only once every 30 seconds.
        if ((++Tick % 60) != 0) return;

        // Perform check, if order has been created at all. If not, stop executing the code.
        if (OrderStats == null) return;

        // Check if there are any workers for this order
        if (OrderStats.Workers == 0)
        {
          MaxPrice += 0.005;
          Console.WriteLine("Increasing order #" + OrderStats.ID.ToString() + " maximal price to: " + MaxPrice.ToString("F4"));
        } else {

          // Try to lower the Max Price
          MaxPrice -= 0.01;
          Console.WriteLine("Decreaseing order #" + OrderStats.ID.ToString() + " maximal price to: " + MaxPrice.ToString("F4"));

        }

    }

    /// <summary>
    /// Property used for measuring time.
    /// </summary>
    private static int Tick = -10;

}
