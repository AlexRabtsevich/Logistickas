   M S B A M L   `   `   `  ����F  BLogistickas, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:LogistickasLogistickas  5           Logistickas.Make_Deal_Page   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      %localclr-namespace:Logistickas  5      .��5      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TransitionigContentSlide��5   .   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6P   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.8X�.��5      � .+�5      � -   5         �Name$ GridMake��5      $	��700��6)   $��0 0 0 0q�66   ���	#FFCBE4EE.+�5      � $��60��6   $
��1118��6(   $	��Top=�65   
���   �.+�5      �� 
������� �� Orientation$ 
Horizontal=�6<   $��Center=�6U   $��	0 0 0 2.5q�6p   $
��57.5��6�   .+�5      �� -   5         ��Name$ Panel1��5   )   $��Center=�69   $	��100��6V   $��20��6b   $��	340 0 5 0q�6n   
�������6�   �� 5      -   5        $ Panel2��5   )   $��Center=�69   $	��100��6V   $��20��6b   $��5q�6n   
�������6y   �� 5      -   5        $ Panel3��5   )   $��Center=�69   $	��100��6V   $��20��6b   $��5q�6n   
�������6y   �� 5      -   5        $ Panel4��5   )   $��Center=�69   $	��100��6V   $��20��6b   $��5q�6n   
�������6y   5      5      � 5      $	��300��6   $	��280��6(   $
��Left=�64   $��70 0 0 0q�6O   
���   �.+�5      �� $ Vertical=�6)   $	��295��6@   $
�� 275��6M   
�������.+�5      �� $+��%Шаг 1: Выбор водителя��6(   $��21(�6E   $��15q�6S   �� 5      $	��240��6(   $��21(�64   $	��190��6B   $����Для оформления заказа нажмите кнопку -Далее-. В появившимся окне выберите водителя для осуществления заказа. ��6O   $
��Wrap=�6�   5       5      � 5      $	��300��6    $	��280��6-   $
��Left=�69   $��	410 0 0 0q�6T   
���   �.+�5      �� $ Vertical=�6(   $	��295��6?   $
�� 275��6L   
�������.+�5       �� $+��%Шаг 2: Место Выгрузки��6(   $��21(�6E   $��15q�6S   �� 5!      $	��240��6(   $��21(�64   $	��190��6B   $����В окне место выгрузки товара, выберите место из предложенных. Либо введите свое место выгрузки.��6O   $
��Wrap=�6�   5"      5#      � 5$      $	��300��6    $	��280��6-   $
��Left=�69   $��	750 0 0 0q�6T   
���   �.+�5%      �� $ Vertical=�6)   $	��295��6@   $
�� 275��6M   
�������.+�5&      �� $'��!Шаг 3: Выбор товара��6(   $��21(�6C   $��15q�6Q   �� 5'      $	��240��6(   $��21(�64   $	��190��6B   $����В талице выберите товар и его количество для доставки в место выгрузки выбранным водителем. ��6O   $
��Wrap=�6�   5(      5)      � 5*      $��90��6    
���   �$��Bottom=�6?   .+�5+      �� $ 
Horizontal=�6*   
�������$��85��6Z   .+�5,   "   �� -   5         ��Name$ Button_Next��5,   e   $��50��6)   $��	480 0 0 0q�65   $��
Далее��6I   $	��150��6Y   6z   5-       5.      5/      50      51      52      53      