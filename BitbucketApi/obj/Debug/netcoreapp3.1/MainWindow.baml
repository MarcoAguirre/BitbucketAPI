   M S B A M L   `   `   `  ����G  CBitbucketApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:BitbucketApiBitbucketApi  5   	       BitbucketApi.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:BitbucketApi     5   	     � Title$  
MainWindow��5   	   $	��400��6   $	��500��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��20 �6   �� 5      $��90 �6   �� 5      $��30 �6   �� 5      .+�5   
   �� $0��*Enter your Bitbucket username and password��6   $��20��6F   $
��Auto��6R   $��Center=�6_   $��Center=�5      $��0��6/   $
��Bold"�6<   �� 5   
   $��Username��6   $��20��6$   $
��Auto��60   $��Center=�6=   $��1��6Z   $
��Bold"�6g   $	��Top=�5      �� 5   
   -   5         ��Name$ txtUserName��5      $��20��6'   $	��300��63   $��Center=�6?   $��1��6\   $��Center=�5      $��0,0,0,30q�6-   �� 5   
   $��Password��6   $��20��6$   $
��Auto��60   $��Center=�6=   $��1��6Z   $
��Bold"�6g   $��Center=�5      $��0,20,0,0q�6/   G� 5   
   -   5         G�Name$ 
pbPassword��5      $��20��6*   $	��300��66   $��Center=�6B   $��1��6_   $��Bottom=�5      $��0,0,0,0q�6-   �� 5   
   -   5         ��Name$ btnGet��5      $	��GET��6!   $��50��6/   $��20��6:   $��Center=�6F   $��2��6c   5      �� 5   
   -   5         ��Name$ lvRepositories��5      $
��Auto��6+   $
��Auto��68   $��3��6F    �� View 5      �� 5      .P�5      �� $��Repository Name��6%    �� Width$	 150��6>    �� DisplayMemberBinding 6J   �� *m_strRepositoryName+	 �� Mode$	 TwoWay=��� 5!      $��Repository Description��6%   $
 Auto��6E    6R   �� *m_strRepositoryCommentary+$	 TwoWay=�5#      5%      5&      5'      