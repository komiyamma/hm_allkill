/*
 * This codes is licensed under CC0 1.0 Universal
 */

using System;
using System.Threading.Tasks;

namespace HmAllKill;

public class Program
{
    /// <summary>
    /// エントリポイント。秀丸の自然終了→強制終了を順に実施
    /// </summary>
    public static async Task Main(string[] args)
    {
        try
        {
            // 自然終了を試みる
            await HidemaruProcessManager.RequestGracefulCloseAsync();

            // 終了まで待機（最大3回）
            for (int i = 0; i < 3; i++)
            {
                if (System.Diagnostics.Process.GetProcessesByName("hidemaru").Length == 0)
                    return;
                await Task.Delay(200);
            }
            // 強制終了
            HidemaruProcessManager.KillAll();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"[HmAllKill] エラー: {ex.Message}");
        }
    }
}
