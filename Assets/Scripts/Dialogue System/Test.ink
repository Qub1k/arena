-> begin
=== begin ===
Okay and now
    *[skjnia]
        Okay. Do you want to hear more details?
            **[yes]
                Great! Let me explain further?*
                *** hh -> after()
                    
            **[no]
                Alright, let's move on. 
                -> DONE
    *[no]
        Hmmm. Should I explain it to you?
            **[yes]
                Alright, here's the explanation. 
                -> DONE
            **[no]
                No problem, let's leave it at that.
                -> DONE

=== after() ===
wth
    *[w?]
        -> DONE
    *[y?]
        -> DONE