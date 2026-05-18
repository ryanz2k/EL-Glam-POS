import json

services_text = """
Facial Care: Signature Facial (399), Facial with Diamond Peel (499), Facial Combo (599), Facial Botox (699), Acne Control Treatment (899), Backcial (999), Melasma Care Treatment (2499), Korean BB Glow (1299), Hydra-Facial Treatment (999), Carbon Laser Facial (999).

Warts removal: Unlimited Face Area (799), Unlimited Neck Area (799), Unlimited Face & Neck Area (1499).

Eyelash Care - Lift: Eyelash Lifting (499), Eyelash Lifting with Tint (599).

Eyelash Care - Extensions: Synthetic Eyelashes (599), Regular Human Hair (799), Ultrasoft Human Hair (899).

Semi-Permanent Make Up: Micro-Shading 1 Session (2499), Micro-Shading 2 Session (3999), Eyeliner 1 Session (2499), Eyeliner 2 Session (3999), Lip Tattoo 1 Session (2499), Lip Tattoo 2 Session (3999).

Gluta Push & Drip: Vitamin C Shot (199), Collagen Shot (380), Stem Cell (380), Gluta I.V. Push (380), Placenta (499), Glamorous White Shot (599), Express White Drip (999), Snow White Drip (1699), Cindella Drip (1799), Hikari Drip (1799).

Eyebrows Care: Brow Lamination (399), Brow Lamination with Tint (449).

Hair & Make Up: Hairdo/Styling (500), Make Up (500), Hair & Make Up (800).

Hair Care - Men: Haircut (150), Haircut with Shampoo (250), Haircut with Color (1000).

Hair Care - Women: Haircut (250), Haircut with Shampoo (350), Hair Iron/Blowdry (350).

Special Treatment: Loreal Power Dose (1500), Plarmia Scalp Treatment (1500), Grand Linkage (2000), Hair Cellophane (800).

Hair Color: Hair Color with Treatment (1500 base), Hair Color/Highlights/Treatment (2500 base), Hair Balayage (3000 base).

Rebonding: Regular Hair Rebond (1500 base), Premium Hair Rebond (3000 base).

Brazilian Treatment: Brazilian Treatment (1500 base), Brazilian Treatment + Hair Color (2500 base), Brazilian Treatment + Hair Rebond (2500 base).

Combo: Hair Color/Rebond/Brazilian (3000 base), Highlights/Color/Rebond/Brazilian (3500 base).

Body Care: Body Scrub & Whitening (999), Underarm Whitening (499), Underarm Premium Glow (899), Butt/Bikini Line Whitening (599), Bikini Premium Glow (1199), Elbows/Knees Whitening (499).

Facial & Body Slimming: RF Facial Contour (349), RF with Cavitation per area (599), RF Arms/Tummy/Back (1499), Mesotherapy with FREE RF per vial (999), Ultherapy Face Area (3999), Ultherapy other areas (5999), Trio Slim (999).

Massage: Full Body Massage 60 Mins (599), Full Body Massage 30 Mins (399), Foot Massage 60 Mins (349), Foot Massage 30 Mins (249), Ventosa Cupping 60 Mins (699).

Nail Care - Regular Polish: Manicure (150), Pedicure with Soaking (200), Pedicure with Footspa (450).

Nail Care - Imported Polish: Manicure (230), Pedicure with Soaking (300), Pedicure with Footspa (550).

Nail Care - Gel Polish: Manicure (550), Pedicure with Soaking (600), Pedicure with Footspa (750), Foot Spa Alone (350).

Nail Extensions: Imported Extensions (1599), Soft Gel Extensions (1299).

Others: Additional Nail Art (350), Stones (10).

Waxing/Threading: Eyebrows Threading (120), Eyebrows Waxing (149), Upper Mouth (149), Lower Mouth (149), Underarms (199), Brazilian/Bikini Line (699), Arms - Women (299 base), Legs - Women (499 base).

Permanent Hair Removal: Underarm Hair Removal (699), Underarm Whitening (699), Underarm Removal & Whitening (1099), Lower/Upper Mouth (399), Lower & Upper Mouth Combo (599), Arms (399 base), Legs (599 base), Brazilian/Bikini Line (999), Pigmentation Laser (899), Acne/Skin Rejuvenating Laser (899).
"""

categories = []
services = []
cat_id = 1
serv_id = 1

import re

for line in services_text.strip().split('\n'):
    line = line.strip()
    if not line: continue
    
    parts = line.split(':')
    if len(parts) == 2:
        cat_name = parts[0].strip()
        items_str = parts[1].strip()
        
        categories.append(f'new ServiceCategory {{ Id = {cat_id}, Name = "{cat_name}" }}')
        
        # Parse items: Name (Price)
        # e.g., Signature Facial (399), Hair Color with Treatment (1500 base)
        # We can split by '), ' or similar, but better to use regex
        
        items = items_str.split('),')
        for item in items:
            item = item.strip()
            if not item: continue
            if not item.endswith(')'):
                if item.endswith('.'):
                    item = item[:-1]
                if not item.endswith(')'):
                    item += ')'
            
            # Extract name and price
            match = re.match(r'(.+)\s*\((.+)\)', item)
            if match:
                name = match.group(1).strip()
                price_str = match.group(2).strip()
                
                is_base = 'base' in price_str.lower()
                price_val = re.sub(r'[^\d.]', '', price_str)
                
                services.append(f'new ServiceItem {{ Id = {serv_id}, Name = "{name}", BasePrice = {price_val}m, IsVariablePrice = {"true" if is_base else "false"}, CategoryId = {cat_id}, Type = ItemType.Service }}')
                serv_id += 1
        
        cat_id += 1

print("Categories:")
print(",\n".join(categories))
print("\nServices:")
print(",\n".join(services))
