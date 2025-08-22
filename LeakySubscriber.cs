namespace GCLab;

class LeakySubscriber : IDisposable
{
    private static readonly List<LeakySubscriber> _registry = new();
    private Publisher _publisher;

    public LeakySubscriber(Publisher publisher) 
    {
        _publisher = publisher;
        _publisher.OnSomething += Handle;
        _registry.Add(this);
    }

    private void Handle() { /* noop */ }

    public void Dispose() {
        if (_publisher != null) {
            _publisher.OnSomething -= Handle;
            _publisher = null;
        }
        _registry.Remove(this);
    }
}
