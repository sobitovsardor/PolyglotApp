using PolyglotApp.Desktop.Pages;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace PolyglotApp.Desktop;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        UpdateMaximizeRestoreButton();
    }

    private void DictionaryPage_Click(object sender, RoutedEventArgs e)
    {
        NavigateToPage(new DictionarySectionPage());
    }

    private void GamePage_Click(object sender, RoutedEventArgs e)
    {
        // GamePage yaratilganda bu qatorni uncomment qiling
        // NavigateToPage(new GamePage());

        // Hozircha placeholder message
        MessageBox.Show("Game Page coming soon!", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void NavigateToPage(object page)
    {
        // Fade out welcome card with animation
        var fadeOutStoryboard = new Storyboard();
        var fadeOutAnimation = new DoubleAnimation
        {
            From = 1.0,
            To = 0.0,
            Duration = TimeSpan.FromSeconds(0.3)
        };

        Storyboard.SetTarget(fadeOutAnimation, WelcomeCard);
        Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("Opacity"));
        fadeOutStoryboard.Children.Add(fadeOutAnimation);

        fadeOutStoryboard.Completed += (s, e) =>
        {
            WelcomeCard.Visibility = Visibility.Collapsed;

            // Show main frame and back button
            MainFrame.Visibility = Visibility.Visible;
            BackButton.Visibility = Visibility.Visible;

            // Navigate to the page
            MainFrame.Navigate(page);

            // Fade in main frame
            var fadeInStoryboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            Storyboard.SetTarget(fadeInAnimation, MainFrame);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity"));
            fadeInStoryboard.Children.Add(fadeInAnimation);
            fadeInStoryboard.Begin();
        };

        fadeOutStoryboard.Begin();
    }

    private void BackToHome_Click(object sender, RoutedEventArgs e)
    {
        // Fade out main frame
        var fadeOutStoryboard = new Storyboard();
        var fadeOutAnimation = new DoubleAnimation
        {
            From = 1.0,
            To = 0.0,
            Duration = TimeSpan.FromSeconds(0.3)
        };

        Storyboard.SetTarget(fadeOutAnimation, MainFrame);
        Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("Opacity"));
        fadeOutStoryboard.Children.Add(fadeOutAnimation);

        fadeOutStoryboard.Completed += (s, e) =>
        {
            MainFrame.Visibility = Visibility.Collapsed;
            BackButton.Visibility = Visibility.Collapsed;

            // Show welcome card
            WelcomeCard.Visibility = Visibility.Visible;

            // Fade in welcome card
            var fadeInStoryboard = new Storyboard();
            var fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = TimeSpan.FromSeconds(0.3)
            };

            Storyboard.SetTarget(fadeInAnimation, WelcomeCard);
            Storyboard.SetTargetProperty(fadeInAnimation, new PropertyPath("Opacity"));
            fadeInStoryboard.Children.Add(fadeInAnimation);
            fadeInStoryboard.Begin();
        };

        fadeOutStoryboard.Begin();
    }

    private void CloseApp_Click(object sender, RoutedEventArgs e)
    {
        // Smooth exit animation
        var fadeOutStoryboard = new Storyboard();
        var fadeOutAnimation = new DoubleAnimation
        {
            From = 1.0,
            To = 0.0,
            Duration = TimeSpan.FromSeconds(0.2)
        };

        Storyboard.SetTarget(fadeOutAnimation, this);
        Storyboard.SetTargetProperty(fadeOutAnimation, new PropertyPath("Opacity"));
        fadeOutStoryboard.Children.Add(fadeOutAnimation);

        fadeOutStoryboard.Completed += (s, e) => Application.Current.Shutdown();
        fadeOutStoryboard.Begin();
    }

    // Window control methods
    private void MinimizeButton_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }

    private void MaximizeRestoreButton_Click(object sender, RoutedEventArgs e)
    {
        if (WindowState == WindowState.Normal)
        {
            WindowState = WindowState.Maximized;
        }
        else
        {
            WindowState = WindowState.Normal;
        }
        UpdateMaximizeRestoreButton();
    }

    private void UpdateMaximizeRestoreButton()
    {
        if (WindowState == WindowState.Maximized)
        {
            MaximizeRestoreButton.Content = "❐"; // Restore icon
            MaximizeRestoreButton.ToolTip = "Restore";
        }
        else
        {
            MaximizeRestoreButton.Content = "□"; // Maximize icon
            MaximizeRestoreButton.ToolTip = "Maximize";
        }
    }

    private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            // Double-click to maximize/restore
            MaximizeRestoreButton_Click(sender, e);
        }
        else
        {
            // Single click to drag window
            DragMove();
        }
    }

    // Handle window state changes to update the maximize/restore button
    protected override void OnStateChanged(EventArgs e)
    {
        UpdateMaximizeRestoreButton();
        base.OnStateChanged(e);
    }
}