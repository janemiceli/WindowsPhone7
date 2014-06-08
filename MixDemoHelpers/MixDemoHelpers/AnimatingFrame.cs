using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace MixDemoHelpers
{
  /// <summary>
  /// This class performs animation between pages.
  /// </summary>
  [TemplatePart(Name = AnimatingFrame.OldTemplatePart, Type = typeof(ContentPresenter))]
  [TemplatePart(Name = AnimatingFrame.NewTemplatePart, Type = typeof(ContentPresenter))]
  public class AnimatingFrame : PhoneApplicationFrame
  {
    bool isForward = false;
    ContentPresenter oldContentPresenter;
    ContentPresenter newContentPresenter;

    public AnimatingFrame()
    {
      DefaultStyleKey = typeof(AnimatingFrame);
      // MIX10: Note that a bug prevents this from being called when you go back with the
      // hardware key, so you will always see the 'forward' navigation if you use the
      // hardware key
      this.Navigating += (s, e) => { isForward = (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back); };
    }

    public override void OnApplyTemplate()
    {
      base.OnApplyTemplate();

      oldContentPresenter = GetTemplateChild(OldTemplatePart) as ContentPresenter;
      newContentPresenter = GetTemplateChild(NewTemplatePart) as ContentPresenter;

      (GetTemplateChild("AnimationStates") as VisualStateGroup).CurrentStateChanged += OnStateChanged;

      if (Content != null)
        OnContentChanged(null, Content);
    }

    /// <summary>
    /// Removes the old content from the tree once the animation is over
    /// </summary>
    private void OnStateChanged(object sender, VisualStateChangedEventArgs e)
    {
      if (e.NewState.Name == "Loaded" && oldContentPresenter != null)
        oldContentPresenter.Content = null;
    }

    /// <summary>
    /// Switches content and animates the two content presenters whenever the content
    /// of the control is updated (ie, it is navigated).
    /// </summary>
    protected override void OnContentChanged(object oldContent, object newContent)
    {
      base.OnContentChanged(oldContent, newContent);

      if (newContentPresenter == null || oldContentPresenter == null)
        return;

      newContentPresenter.Content = newContent;
      oldContentPresenter.Content = oldContent;

      if (isForward)
      {
        VisualStateManager.GoToState(this, "BeforeLoad", false);
        VisualStateManager.GoToState(this, "Loaded", true);
      }
      else
      {
        VisualStateManager.GoToState(this, "AfterLoad", false);
        VisualStateManager.GoToState(this, "Loaded", true);
      }
    }

    public const string OldTemplatePart = "OldContent";
    public const string NewTemplatePart = "NewContent";
  }
}
