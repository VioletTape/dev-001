using System.Collections;

namespace TryOut._11Iterator.Refactored;

public class LeafPartEnumerator : IEnumerator<ICarPart>, IEnumerable<ICarPart> {
    ICarPart part;
    List<ICarPart> collection;
    int index = 0;


    public LeafPartEnumerator(ICarPart part) {
        this.part = part;
        Current = part;
        collection = GetCollection(part);
    }

    public bool MoveNext() {
        while (index < collection.Count-1) {
            if (collection[index++] is Node) {
                Current = collection[index];
                return true;
            }
        }

        Current = null;
        return false;
    }

    private List<ICarPart> GetCollection(ICarPart cp) {
        var result = new List<ICarPart>(cp.GetParts());
        foreach (var p in cp.GetParts()) {
            result.AddRange(GetCollection(p));
        }
        return result;
    }

    public void Reset() {
        index = 0;
    }

    public ICarPart? Current { get; private set; }

    object IEnumerator.Current
        => Current;

    public void Dispose() {
        collection = null;
        part = null;
    }

    public IEnumerator<ICarPart> GetEnumerator() {
        return this;
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }
}

public class LeafPartEnumerator2 : IEnumerator<ICarPart> {
    ICarPart part;
    List<Node> collection;
    int index = 0;


    public LeafPartEnumerator2(ICarPart part) {
        this.part = part;
        Current = part;
        collection = GetCollection(part).OfType<Node>().ToList();
    }

    public bool MoveNext() {
        while (index < collection.Count) {
            if (collection[index++].Price <= 0) {
                Current = collection[index];
                return true;
            }
        }

        Current = null;
        return false;
    }

    private List<ICarPart> GetCollection(ICarPart cp) {
        var result = new List<ICarPart>(cp.GetParts());
        foreach (var p in cp.GetParts()) {
            result.AddRange(GetCollection(p));
        }
        return result;
    }

    public void Reset() {
        index = 0;
    }

    public ICarPart? Current { get; private set; }

    object IEnumerator.Current
        => Current;

    public void Dispose() {
        collection = null;
        part = null;
    }
}

public class PriceAnomalyEnumerator : IEnumerator<ICarPart> {
    ICarPart part;
    List<ICarPart> collection;
    int index = 0;


    public PriceAnomalyEnumerator(ICarPart part) {
        this.part = part;
        Current = part;
        collection = GetCollection(part);
    }

    public bool MoveNext() {
        if (index < collection.Count) {
            Current = collection[index++];
            return true;
        }

        Current = null;
        return false;
    }

    private List<ICarPart> GetCollection(ICarPart cp) {
        var result = new List<ICarPart>(cp.GetParts());
        foreach (var p in cp.GetParts()) {
            result.AddRange(GetCollection(p));
        }
        return result;
    }

    public void Reset() {
        index = 0;
    }

    public ICarPart? Current { get; private set; }

    object IEnumerator.Current
        => Current;

    public void Dispose() {
        collection = null;
        part = null;
    }
}