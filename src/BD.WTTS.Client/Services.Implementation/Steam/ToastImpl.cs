// ReSharper disable once CheckNamespace
namespace BD.WTTS.Services.Implementation;

/// <summary>
/// 使用 <see cref="ToastService"/> 实现的 <see cref="IToast"/>
/// </summary>
internal sealed class ToastImpl : ToastBaseImpl
{
    public ToastImpl(IToastIntercept intercept, IMainThreadPlatformService mainThread) : base(intercept, mainThread)
    {
    }

    protected override bool IsMainThread => MainThread2.IsMainThread();

    protected override void BeginInvokeOnMainThread(Action action) => MainThread2.BeginInvokeOnMainThread(action);

    protected override void PlatformShow(string text, int duration)
    {
        ToastService.Current.Notify(text);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static IServiceCollection TryAddToast(IServiceCollection services)
        => TryAddToast<ToastImpl>(services);
}