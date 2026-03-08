namespace CleanBase.Shared.Attributes;

public class LabelAttribute: Attribute
{
  public string Label { get; }
  public LabelAttribute(string label)
  {
    Label = label;
  }
}
