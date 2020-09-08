using System;

public class DTBinaryDecision : DTNode
{
	readonly Func<bool> testFunction;
	readonly DTNode trueTree, falseTree;

	public DTBinaryDecision(Func<bool> testFunction, DTNode trueTree, DTNode falseTree)
	{
		this.testFunction = testFunction;
		this.trueTree = trueTree;
		this.falseTree = falseTree;
	}

	public override DTAction MakeDecision()
	{
        DTNode node = testFunction() ? trueTree : falseTree;

        if(node != null) {
            return node.MakeDecision();
        }
        return null;
	}
}
